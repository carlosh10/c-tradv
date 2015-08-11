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
        public const string URL_PROD_SENSE = "http://detalhes.tradeadvisor.com.br/ncm/Consulta?descricao={descricao}&ncm={ncm}";
        public const string URL_DI = null;
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchDIQtde(string paramatro, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, "di", campo, URL_DI);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchProdSenseQtde(string paramatro, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, "prodsense", campo, campo == "ncm" ? URL_PROD_SENSE : null);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, string url)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, 50, url);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros, string url)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, qtde_registros, "documents", url);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros, string index, string url)
        {
            var node = new Uri("http://104.197.50.109:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro);

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
                        )
                    )
                )
            );

            var listBuckets = (Bucket)result.Aggregations["name"];

            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();

            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
                resumoBusca.name = listKeyItem.Key;

                resumoBusca.qtde = (long)((ValueMetric)listKeyItem.Aggregations["qtde"]).Value;

                resumoBusca.url = url;

                listResultados.Add(resumoBusca);
            }

            return listResultados;
        }


        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumDIValor(string paramatro, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, "di", campo, URL_DI);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumProdSenseValor(string paramatro, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, "prodsense", campo, campo == "ncm" ? URL_PROD_SENSE : null);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, 50, url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, "documents", url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index, string url)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, index, "CIF", url);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index, string campo_sum, string url)
        {
            var node = new Uri("http://104.197.50.109:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var filterQuery = Query<PRODUTOS_SENSIVEIS_POCO>.Terms("descricao_detalhada_produto", paramatro);

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
                )
            );

            var listBuckets = (Bucket)result.Aggregations["name"];

            List<AgregationsPorBucketValor> listResultados = new List<AgregationsPorBucketValor>();

            foreach (KeyItem listKeyItem in listBuckets.Items)
            {
                AgregationsPorBucketValor resumoBusca = new AgregationsPorBucketValor();
                resumoBusca.name = listKeyItem.Key;

                resumoBusca.valor = (long)((ValueMetric)listKeyItem.Aggregations["valor"]).Value;

                resumoBusca.url = url;

                listResultados.Add(resumoBusca);
            }

            return listResultados;
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchCountDocumentos(string paramatro)
        {
            return ConsultaElasticSearchCountDocumentos(paramatro, "documents");
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchCountDocumentos(string paramatro, string index)
        {
            var node = new Uri("http://104.197.50.109:9400");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var filterQuery = Query<DIPOCO>.Terms("tx_descricaoMercadoria", paramatro);

            var resultDI = client.Count<DIPOCO>(c => c
                .Index(index)
                .Type("di")
                .Query(q => q
                    .Match(m => m
                        .OnField("tx_descricaoMercadoria")
                        .Query(paramatro)
                    )
                )
            );

            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();

            AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
            resumoBusca.name = "DI";
            resumoBusca.qtde = resultDI.Count;
            listResultados.Add(resumoBusca);

            //Consultando CE
            filterQuery = Query<CE_POCO>.Terms("txmercadoria", paramatro);
            var resultCE = client.Count<CE_POCO>(c => c
                                            .Index(index)
                                            .Type("ce")
                                            .Query(q => q
                                                .Match(m => m
                                                    .OnField("txmercadoria")
                                                    .Query(paramatro)
                                                )
                                            )
                                        );
            resumoBusca = new AgregationsPorBucketQtde();
            resumoBusca.name = "CE";
            resumoBusca.qtde = resultCE.Count;
            listResultados.Add(resumoBusca);

            return listResultados;
        }

        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchDocCompany(string parametro)
        {
            var node = new Uri("http://104.197.50.109:9400");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            var filterQuery = Query<ES_DOCUMENTS_POCO>.MultiMatch(mm => mm
                                                                        .Query(parametro)
                                                                        .OnFields(
                                                                            f => f.tx_descricaoMercadoria,
                                                                            f => f.txmercadoria)
                                                                                );
            var result = client.Search<AgregationsPorBucketQtde>(s => s
                                                                 .Index("documents")
                                                                .SearchType(Elasticsearch.Net.SearchType.Count)
                                                                .AllTypes()
                                                                .Query(filterQuery)
                                                                .Size(50)
                                                                 .Aggregations(a => a
                                                                                .Terms("DI", terDI => terDI
                                                                                        .Field("tx_cnpj")
                                                                                )
                                                                                .Terms("CE", terCE => terCE
                                                                                        .Field("cdconsignatario")
                                                                                )
                                                                              )
                                                                 );


            List<AgregationsPorBucketQtde> listResultados = new List<AgregationsPorBucketQtde>();


            //DI Values
            var listBucketsDI = (Bucket)result.Aggregations["DI"];

            foreach (KeyItem listKeyItem in listBucketsDI.Items)
            {
                AgregationsPorBucketQtde resumoBusca = new AgregationsPorBucketQtde();
                //incluir aqui a busca pelo nome da empresa
                resumoBusca.name = DIDAO.ConsultaEmpresaDIPorCnpj(listKeyItem.Key) + "/" + listKeyItem.Key;
                resumoBusca.qtde = listKeyItem.DocCount;

                listResultados.Add(resumoBusca);
            }
            //CE Values
            var listBucketsCE = (Bucket)result.Aggregations["CE"];

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
            var node = new Uri("http://104.197.50.109:9400");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);

            List<AgregationsPorBucketQtdexDate> listResultados = new List<AgregationsPorBucketQtdexDate>();

            //DI
            listResultados.AddRange(searchQtdxDate(client, "tx_descricaoMercadoria", paramatro, "di", "dt_registro"));
            listResultados.AddRange(searchQtdxDate(client, "txmercadoria", paramatro, "ce", "dtemissaoce"));
            
            return listResultados;
        }


        private static List<AgregationsPorBucketQtdexDate> searchQtdxDate(ElasticClient client, string filter_field, string parameter, string doc_type, string date_field)
        {
            List<AgregationsPorBucketQtdexDate> listResultados = new List<AgregationsPorBucketQtdexDate>();
            var filterQuery = Query<ES_DOCUMENTS_POCO>.Terms(filter_field, parameter);

            var result = client.Search<AgregationsPorBucketQtdexDate>(s => s
                .Index("documents")
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