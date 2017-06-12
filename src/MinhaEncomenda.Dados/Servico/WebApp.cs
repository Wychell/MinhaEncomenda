using MinhaEncomenda.Negocio.Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace MinhaEncomenda.Dados.Servico
{
    public class WebApp : IWebApi
    {
        public Task<T> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<T> PostAsync<T>(string url, string codigo)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var response = await cliente.PostAsync(url, ParametrosPost(codigo));
                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), new IsoDateTimeConverter
                        {
                            Culture = new System.Globalization.CultureInfo("pt-BR")
                        });

                    return default(T);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private StringContent ParametrosPost(string codigo)
        {
            var body = $@"";

            return new StringContent(body, Encoding.UTF8, "application/xml");
        }
    }
}
