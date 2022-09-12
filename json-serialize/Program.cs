using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace play
{

    [DataContract]
    class BlogSite
    {
        [DataMember]
        public string? Name { get; set; }

        [DataMember]
        public string? Description { get; set; }
    }

    class VlogSite
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    class Program
    {
        public static void Main(String[] args)
        {
            // dataContractJsonSerializer();
            jsonNet();
        }

        public static void jsonNet()
        {
            VlogSite vsObj = new VlogSite
            {
                Name = "Name",
                Description = "Desctiption"
            };

            string jsonData = JsonConvert.SerializeObject(vsObj);
            Console.WriteLine(jsonData);

            VlogSite? vs = JsonConvert.DeserializeObject<VlogSite>(jsonData);
            Console.WriteLine(vs?.Name);
            Console.WriteLine(vs?.Description);
        }

        public static void javaScriptJsonSerializer()
        {
            VlogSite vsObj = new VlogSite
            {
                Name = "Name",
                Description = "Desctiption"
            };



        }

        //DataContractJsonSerializer
        public static void dataContractJsonSerializer()
        {

            BlogSite bsObj = new BlogSite
            {
                Name = "Name",
                Description = "Desctiption"
            };
            //Serialization
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(BlogSite));
            MemoryStream obj = new MemoryStream();
            js.WriteObject(obj, bsObj);
            obj.Position = 0;
            StreamReader sr = new StreamReader(obj);
            string json = sr.ReadToEnd();
            Console.WriteLine(json);
            //Deserialization
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(BlogSite));
            BlogSite? bsObj2 = (BlogSite?)deserializer.ReadObject(ms);
            Console.Write(bsObj.Name);
            Console.Write(bsObj.Description);

            sr.Close();
            obj.Close();
            ms.Close();

        }
    }
}