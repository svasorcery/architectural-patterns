using System.Net.Http;
using Newtonsoft.Json;
using SvaSorcery.Patterns.Enterprise.InputOutput.PagingIterator.Types;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.PagingIterator
{
    public class GithubSearchPagedIterator : AbstractPagedIterator<object>
    {
        private readonly string _baseUrl = "https://api.github.com/search/repositories";
        private readonly HttpClient _httpClient;
        private int _totalSize;
        private readonly string _term;

        public GithubSearchPagedIterator(string term)
        {
            _httpClient = new HttpClient();
            _term = term;
            _totalSize = 0;
            GetPage(0);
        }

        public override int GetTotalSize() => _totalSize;

        public override int GetPageSize() => 100;

        public override object[] GetPage(int pageNumber)
        {
            var url = $"{_baseUrl}?q={_term}&page={pageNumber}";

            var response = _httpClient.GetStringAsync(url).Result;

            var result = JsonConvert.DeserializeObject<GithubResult>(response);

            _totalSize = result.TotalCount;

            return result.Items;
        }
    }

    public class GithubResult
    {
        public int TotalCount { get; set; }
        public object[] Items { get; set; }
    }
}
