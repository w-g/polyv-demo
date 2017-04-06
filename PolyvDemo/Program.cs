using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PolyvDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoPlayerService = new VideoPlayerService();

            videoPlayerService.Upload();

            Console.ReadKey();
        }
    }

    class VideoPlayerService
    {

        public void Upload()
        {
            var postParameters = new List<KeyValuePair<string, string>>();

            postParameters.Add(new KeyValuePair<string, string>("writetoken", "559c94ec-9927-4ff9-a978-e3d4c23fc916"));
            postParameters.Add(new KeyValuePair<string, string>("JSONRPC", "{\"title\": \"标题22\", \"tag\":\"标签22\",\"desc\":\"描述22\"}"));
            postParameters.Add(new KeyValuePair<string, string>("Filedata", string.Join("", File.ReadAllBytes(@"E:\迅雷下载\妖精的尾巴001.mp4"))));

            PostAsync("", postParameters);
        }

        private async void PostAsync(string requestUri, IEnumerable<KeyValuePair<string, string>> postParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(postParameters);
                using (var httpResponseMessage = await httpClient.PostAsync("http://v.polyv.net/uc/services/rest?method=uploadfile", content))
                {

                }
            }
        }

        private class ResponseMessageEntity
        {
            string error { get; set; }

            ResponseDataEntity[] data { get; set; }
        }

        private class ResponseDataEntity
        {
            string[] images_b { get; set; }

            string md5checksum { get; set; }

            string tag { get; set; }

            string mp4 { get; set; }

            string title { get; set; }

            int df { get; set; }

            string times { get; set; }

            string mp4_1 { get; set; }

            string vid { get; set; }

            string cataid { get; set; }

            string swf_link { get; set; }

            long source_filesize { get; set; }

            string status { get; set; }

            int seed { get; set; }

            string flv1 { get; set; }

            string sourcefile { get; set; }

            string playerwidth { get; set; }

            string default_video { get; set; }

            string duration { get; set; }

            int[] filesize { get; set; }

            string first_image { get; set; }

            string original_definition { get; set; }

            string[] images { get; set; }

            string playerheight { get; set; }

            string ptime { get; set; }
        }
    }
}
