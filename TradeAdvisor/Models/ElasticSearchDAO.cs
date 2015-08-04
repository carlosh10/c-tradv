using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeAdvisor.Models
{
    public class ElasticSearchDAO
    {
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, "prodsense", campo);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, 50);
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros)
        {
            return ConsultaElasticSearchQtde(paramatro, type_document, campo, qtde_registros, "documents");
        }
        public static List<AgregationsPorBucketQtde> ConsultaElasticSearchQtde(string paramatro, string type_document, string campo, int qtde_registros, string index)
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

                listResultados.Add(resumoBusca);
            }

            return listResultados;
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, "prodsense", campo);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, 50);
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, "documents");
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index)
        {
            return ConsultaElasticSearchSumValor(paramatro, type_document, campo, qtde_registros, index, "CIF");
        }
        public static List<AgregationsPorBucketValor> ConsultaElasticSearchSumValor(string paramatro, string type_document, string campo, int qtde_registros, string index, string campo_sum)
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