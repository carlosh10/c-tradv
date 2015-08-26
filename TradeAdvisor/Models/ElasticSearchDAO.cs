using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Nest;

namespace TradeAdvisor.Models
{
    public class ElasticSearchDAO
    {
        public const string URL_PROD_SENSE = "/ncm/detalhesimportacao?descricao={descricao}&ncm={ncm}";
        public const string URI_ES = "http://104.197.50.109:9400";
        public const string URL_DI = null;
        public const string INDEX = "documents_index";
        public const string DI = "di";
        public const string CE = "ce";
        public const string PRODSENSE = "prodsense";

        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchDIQtde(string paramatro, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, DI, campo, URL_DI);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchProdSenseQtde(string paramatro, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, PRODSENSE, campo, campo == "ncm" ? URL_PROD_SENSE : null);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, string url)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, 50, url);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros, string url)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, qtde_registros, INDEX, url);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros, string index, string url)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro.ToLower());
            var result = client.Search<AgregationsPorBucketQtde>(s => s
                .Index(index)
                .Type(type_document)
                .SearchType(Elasticsearch.Net.SearchType.Count)
                .Query(filterQuery)
                .Aggregations(a => a
                    .Terms("name", st => st
                        .Field(campo)
                        .Size(qtde_registros)
                        .Aggregations(aa => aa
                            .ValueCount("qtde", m => m
                                .Field(campo)
                            )
                            .Cardinality("desc", m => m
                                .Field("descricao")
                            )
                        )
                    )
                     .Terms("desc", st => st
                        .Field("DESCRICAO")
                        .Size(qtde_registros)
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["name"];

            Bucket listBucketsDesc = null;

            if (campo.Equals("ncm"))
                listBucketsDesc = (Bucket)result.Aggregations["desc"];

            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();

            int count = 0;
            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
                resumoBusca.name = listKeyItem.Key;
                resumoBusca.qtde = (long)((ValueMetric)listKeyItem.Aggregations["qtde"]).Value;
                resumoBusca.url = url;
                if (campo.Equals("ncm"))
                {
                    //This call will Load NCM´s list only once
                    //NcmDAO.loadStaticNCM();
                    //resumoBusca.desc = StaticNCM.getNCMDesc(resumoBusca.name);

                    int countDesc = 0;
                    foreach (KeyItem listKeyItemDesc in listBucketsDesc.Items)
                    {
                        if (count == countDesc)
                        {
                            resumoBusca.desc = listKeyItemDesc.Key;
                            break;
                        }
                        countDesc++;
                    }
                }
                listResultados.Add(resumoBusca);
                count++;
            }
            return listResultados;
        }


        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumDIValor(string paramatro, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, DI, campo, URL_DI);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumProdSenseValor(string paramatro, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, PRODSENSE, campo, campo == "ncm" ? URL_PROD_SENSE : null);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, 50, url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, INDEX, url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, index, "CIF", url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index, string campo_sum, string url)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro.ToLower());

            var result = client.Search<AgregationsPorBucketValor>(s => s
                .Index(index)
                .Type(type_document)
                .SearchType(Elasticsearch.Net.SearchType.Count)
                .Query(filterQuery)
                .Aggregations(a => a
                    .Terms("name", st => st
                        .Field(campo)
                        .Size(qtde_registros)
                        .Aggregations(aa => aa
                            .Sum("valor", m => m
                                .Field(campo_sum)
                            )
                        )
                    )
                     .Terms("desc", st => st
                        .Field("DESCRICAO")
                        .Size(qtde_registros)
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["name"];

            Bucket listBucketsDesc = null;

            if (campo.Equals("ncm"))
                listBucketsDesc = (Bucket)result.Aggregations["desc"];

            List<AgregationsPorBucketValor> listResultados = new List<AgregationsPorBucketValor>();

            int count = 0;
            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                AgregationsPorBucketValor resumoBusca = new AgregationsPorBucketValor();
                resumoBusca.name = listKeyItem.Key;
                resumoBusca.valor = (long)((ValueMetric)listKeyItem.Aggregations["valor"]).Value;
                resumoBusca.url = url;
                if (campo.Equals("ncm"))
                {

                    //This call will Load NCM´s list only once
                    //NcmDAO.loadStaticNCM();
                    //resumoBusca.desc = StaticNCM.getNCMDesc(resumoBusca.name);
                    int countDesc = 0;
                    foreach (KeyItem listKeyItemDesc in listBucketsDesc.Items)
                    {
                        if (count == countDesc)
                        {
                            resumoBusca.desc = listKeyItemDesc.Key;
                            break;
                        }
                        countDesc++;
                    }
                }
                listResultados.Add(resumoBusca);
                count++;
            }

            return listResultados;
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchCountDocumentos(string paramatro)
        {
            return ConsultaElasticSearchCountDocumentos(paramatro, INDEX);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchCountDocumentos(string paramatro, string index)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var resultDI = client.Count<DIPOCO>(c => c
                .Index(index)
                .Type(DI)
                .Query(q => q
                    .Match(m => m
                        .OnField("tx_descricaoMercadoria")
                        .Query(paramatro.ToLower())
                    )
                )
            );

            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();

            AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
            resumoBusca.name = DI;
            resumoBusca.qtde = resultDI.Count;
            listResultados.Add(resumoBusca);

            //Consultando CE
            var resultCE = client.Count<CE_POCO>(c => c
                                            .Index(index)
                                            .Type(CE)
                                            .Query(q => q
                                                .Match(m => m
                                                    .OnField("txmercadoria")
                                                    .Query(paramatro.ToLower())
                                                )
                                            )
                                        );

            resumoBusca = new AgregationsPorBucketQtde();
            resumoBusca.name = CE;
            resumoBusca.qtde = resultCE.Count;
            listResultados.Add(resumoBusca);

            return listResultados;
        }

        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchDocCompany(string parametro)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<ES_DOCUMENTS_POCO>.MultiMatch(mm => mm
                                                                        .Query(parametro.ToLower())
                                                                        .OnFields(
                                                                            f => f.tx_descricaoMercadoria,
                                                                            f => f.txmercadoria)
                                                                                );
            var result = client.Search<AgregationsPorBucketQtde>(s => s
                                                                 .Index(INDEX)
                                                                .SearchType(Elasticsearch.Net.SearchType.Count)
                                                                .AllTypes()
                                                                .Query(filterQuery)
                                                                .Size(50)
                                                                 .Aggregations(a => a
                                                                                .Terms(DI, terDI => terDI
                                                                                        .Field("tx_cnpj")
                                                                                )
                                                                                .Terms(CE, terCE => terCE
                                                                                        .Field("cdconsignatario")
                                                                                )
                                                                              )
                                                                 );


            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();


            //DI Values
            var listBucketsDI = (Bucket)result.Aggregations[DI];

            foreach (KeyItem listKeyItem in listBucketsDI.Items)
            {
                AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
                //incluir aqui a busca pelo nome da empresa
                resumoBusca.name = DIDAO.ConsultaEmpresaDIPorCnpj(listKeyItem.Key) + "/" + listKeyItem.Key;
                resumoBusca.qtde = listKeyItem.DocCount;

                listResultados.Add(resumoBusca);
            }
            //CE Values
            var listBucketsCE = (Bucket)result.Aggregations[CE];

            foreach (KeyItem listKeyItem in listBucketsCE.Items)
            {
                AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
                resumoBusca.name = CEDAO.ConsultaEmpresaCEPorCnpj(listKeyItem.Key) + "/" + listKeyItem.Key;
                resumoBusca.qtde = listKeyItem.DocCount;

                listResultados.Add(resumoBusca);
            }
            return listResultados;
        }


        public static List<AgregationsPorBucketQtdexDate> ConsultaElasticSearchCountQtdeDocuments(string paramatro)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);

            List<AgregationsPorBucketQtdexDate> listResultados = new List<AgregationsPorBucketQtdexDate>();

            //DI
            listResultados.AddRange(searchQtdxDate(client, "tx_descricaoMercadoria", paramatro, DI, "dt_registro"));
            listResultados.AddRange(searchQtdxDate(client, "txmercadoria", paramatro, CE, "dtemissaoce"));

            return listResultados;
        }


        private static List<AgregationsPorBucketQtdexDate> searchQtdxDate(ElasticClient client, string filter_field, string parameter, string doc_type, string date_field)
        {
            List<AgregationsPorBucketQtdexDate> listResultados = new List<AgregationsPorBucketQtdexDate>();
            var filterQuery = Query<ES_DOCUMENTS_POCO>.Terms(filter_field, parameter.ToLower());

            var result = client.Search<AgregationsPorBucketQtdexDate>(s => s
                .Index(INDEX)
                .Type(doc_type)
                .SearchType(Elasticsearch.Net.SearchType.Count)
                .Query(filterQuery)
                .Aggregations(a => a
                    .DateHistogram("name", dh => dh
                        .Field(date_field)
                        .Interval("month")
                        .Format("yyyy-mm")
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["name"];
            foreach (HistogramItem listKeyItem in listBuckets.Items)
            {
                AgregationsPorBucketQtdexDate resumoBusca = new AgregationsPorBucketQtdexDate();
                resumoBusca.name = doc_type.ToUpper();
                resumoBusca.qtde = listKeyItem.DocCount;
                resumoBusca.eventdate = String.Format("{0:MM-yyyy}", listKeyItem.Date);

                listResultados.Add(resumoBusca);
            }
            return listResultados;
        }

        public static List<long> ConsultaElasticSearchListDocumentos(string paramatro, string docType)
        {
            var client = new ElasticClient(new ConnectionSettings(new Uri(URI_ES)));
            List<long> listResult = new List<long>();
            var pk = "";
            var searchField = "";
            if (docType.Equals(DI))
            {
                pk = "pk_di";
                searchField = "tx_descricaoMercadoria";
            }
            else if (docType.Equals(CE))
            {
                pk = "pk_mercadoria";
                searchField = "txmercadoria";
            }

            var result = client.Search<dynamic>(c => c
                                    .Index(INDEX)
                                    .Type(docType.ToLower())
                                    .Size(10000)
                                    .Fields(pk)
                                    .Query(q => q
                                        .Match(m => m
                                            .OnField(searchField)
                                            .Query(paramatro)
                                        )
                                    )
                                );
            foreach (var doc in result.FieldSelections)
                listResult.Add(doc.FieldValues<long>(pk));
            return listResult;
        }

        public static string AtualizaBuscaHeader(string parametro)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            String result = parametro;

            var seResult = client.Count<dynamic>(c => c
                                            .Index(INDEX)
                                            .Type(PRODSENSE)
                                            .Query(q => q
                                                .Match(m => m
                                                    .OnField("descricao_detalhada_produto")
                                                    .Query(parametro.ToLower())
                                                )
                                            )
                                        );

            result += "|" + seResult.Count;

            seResult = client.Count<dynamic>(c => c
                                            .Index(INDEX)
                                            .Type(DI)
                                            .Query(q => q
                                                .Match(m => m
                                                    .OnField("tx_descricaoMercadoria")
                                                    .Query(parametro.ToLower())
                                                )
                                            )
                                        );

            result += "|" + seResult.Count;

            //Consultando CE
            seResult = client.Count<dynamic>(c => c
                                            .Index(INDEX)
                                            .Type(CE)
                                            .Query(q => q
                                                .Match(m => m
                                                    .OnField("txmercadoria")
                                                    .Query(parametro.ToLower())
                                                )
                                            )
                                        );

            result += "|" + seResult.Count;

            return result;
        }


        public static List<TradeAdvisor.Models.NcmDAO.ResumoConsulta> ConsultaNCMElasticSearch(string paramatro)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro.ToLower());
            var result = client.Search<TradeAdvisor.Models.NcmDAO.ResumoConsulta>(s => s
                .Index(INDEX)
                .Type("prodsense")
                .SearchType(Elasticsearch.Net.SearchType.Count)
                .Query(filterQuery)
                .Aggregations(a => a
                    .Terms("ncm", st => st
                        .Field("ncm")
                        .Size(99999999)
                        .Aggregations(aa => aa
                            .ValueCount("qtde", m => m
                                .Field("ncm")
                            )
                            .Sum("CIFTot", m => m
                                .Field("CIF")
                            )
                        )
                    )
                     .Terms("desc", st => st
                        .Field("DESCRICAO")
                        .Size(99999999)
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["ncm"];

            Bucket listBucketsDesc = null;

            listBucketsDesc = (Bucket)result.Aggregations["desc"];

            List<TradeAdvisor.Models.NcmDAO.ResumoConsulta> listResultados = new List<TradeAdvisor.Models.NcmDAO.ResumoConsulta>();

            int count = 0;
            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                TradeAdvisor.Models.NcmDAO.ResumoConsulta resumoBusca = new TradeAdvisor.Models.NcmDAO.ResumoConsulta();
                resumoBusca.ncm = listKeyItem.Key;
                resumoBusca.countReg = (long)((ValueMetric)listKeyItem.Aggregations["qtde"]).Value;
                resumoBusca.CIFTot = (float)((ValueMetric)listKeyItem.Aggregations["CIFTot"]).Value;

                int countDesc = 0;
                foreach (KeyItem listKeyItemDesc in listBucketsDesc.Items)
                {
                    if (count == countDesc)
                    {
                        resumoBusca.tx_ncm_desc = listKeyItemDesc.Key;
                        break;
                    }
                    countDesc++;
                }

                listResultados.Add(resumoBusca);
                count++;
            }
            return listResultados;
        }

        public static List<TradeAdvisor.Models.NcmDAO.ResumoConsultaDetalhada> ConsultaResumoConsulta(string paramatro, string ncm)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro.ToLower());
            var filterQuery2 = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("ncm", ncm.ToLower());
            var result = client.Search<TradeAdvisor.Models.NcmDAO.ResumoConsultaDetalhada>(s => s
                .Index(INDEX)
                .Type("prodsense")
                .SearchType(Elasticsearch.Net.SearchType.Count)
                .Query(filterQuery && filterQuery2)
                .Aggregations(a => a
                    .Terms("ncm", term => term
                        .Field("ncm")
                        .Aggregations(agg => agg
                            .ValueCount("countReg", st => st
                                .Field("ncm")
                            )
                            .Sum("vl_ift", st => st
                                .Field("CIF")
                            )
                        )
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["ncm"];

            List<TradeAdvisor.Models.NcmDAO.ResumoConsultaDetalhada> listResumo = new List<TradeAdvisor.Models.NcmDAO.ResumoConsultaDetalhada>();

            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                NcmDAO.ResumoConsultaDetalhada resumo = new NcmDAO.ResumoConsultaDetalhada();
                resumo.countReg = (long)((ValueMetric)listKeyItem.Aggregations["countReg"]).Value;
                resumo.vl_ift = (float)((ValueMetric)listKeyItem.Aggregations["vl_ift"]).Value;
                listResumo.Add(resumo);
            }

            return listResumo;
        }

        public static List<PRODUTOS_SENSIVEIS_POCO> ConsultaProdutosSensiveisElasticSearch(string paramatro, string ncm, int startIndex, int blockSize)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro.ToLower());

            var result = client.Search<PRODUTOS_SENSIVEIS_POCO>(s => s
                .Index(INDEX)
                .Type("prodsense")
                .Query(filterQuery)
                .Size(blockSize)
                .Skip((startIndex - 1) * blockSize)
            );

            return (List<PRODUTOS_SENSIVEIS_POCO>)result.Documents;
        }
        public static PRODUTOS_SENSIVEIS_POCO ConsultaProdutoSensivelElasticSearch(int pk_produto_sensivel)
        {
            var node = new Uri(URI_ES);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("pk_ncmrf_15a", pk_produto_sensivel.ToString());

            var result = client.Search<PRODUTOS_SENSIVEIS_POCO>(s => s
                .Index(INDEX)
                .Type("prodsense")
                .Query(filterQuery)
                
            );

            return ((List<PRODUTOS_SENSIVEIS_POCO>)result.Documents).First();
        }

        //TODO: Código necessário para analisar a query
        //var seriesSearch = new SearchDescriptor<AgregationsPorBucket>();
        //seriesSearch.Index("documents")
        //.Type("prodsense")
        //.SearchType(Elasticsearch.Net.SearchType.Count)
        //.Aggregations(a => a
        //    .Terms("name", st => st
        //        .Field("paisOrigem")
        //        .Aggregations(aa => aa
        //            .Sum("cif", m => m
        //                .Field("CIF")
        //            )
        //            .ValueCount("CIF_unitario", m => m
        //                .Field("CIF_unitario")
        //            )
        //        )
        //    )
        //);
        //string searchJson = Encoding.UTF8.GetString(client.Serializer.Serialize(seriesSearch));



        //TODO: Código necessário para consulta no elasticsearch
        //public static List<PRODUTOS_SENSIVEIS_POCO> ConsultaProdutosSensiveis(string paramatro)
        //{
        //    var node = new Uri("http://104.197.50.109:9400");

        //    var settings = new ConnectionSettings(node);

        //    var client = new ElasticClient(settings);

        //    var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro);

        //    //var searchResults = client.Search<PRODUTOS_SENSIVEIS_POCO>(s => s.Index("doc2").Type("prodsense").Query(filterQuery));

        //    var searchResults = client.Search<PRODUTOS_SENSIVEIS_POCO>(s => s.Index("documents").Type("prodsense").Take(10));

        //    return (List<PRODUTOS_SENSIVEIS_POCO>)searchResults.Documents;
        //}
    }
}