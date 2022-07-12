using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataPickerProject.Classes
{
    public class Algorithm
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@key")]
        public string Key { get; set; }
        public object filter { get; set; }
    }

    public class Algorithms
    {
        public List<Algorithm> algorithm { get; set; }
    }

    public class Filter
    {
        [JsonProperty("@filter-value")]
        public string FilterValue { get; set; }

        [JsonProperty("@filter-dimensionkey")]
        public string FilterDimensionkey { get; set; }

        [JsonProperty("@filter-operator")]
        public string FilterOperator { get; set; }

        [JsonProperty("@filter-isdefault")]
        public string FilterIsdefault { get; set; }
    }

    public class Relation
    {
        [JsonProperty("@key")]
        public string Key { get; set; }

        [JsonProperty("@groupby")]
        public string Groupby { get; set; }

        [JsonProperty("@descriptionby")]
        public string Descriptionby { get; set; }

        [JsonProperty("@algorithmid")]
        public string Algorithmid { get; set; }

        [JsonProperty("@useitemsetsfolder")]
        public string Useitemsetsfolder { get; set; }
        public Filter filter { get; set; }
    }

    public class Samestyledifferentlook
    {
        public List<Relation> relation { get; set; }
    }

    public class Goeswellwith
    {
        public List<Relation> relation { get; set; }
    }

    public class Neededitems
    {
        public List<Relation> relation { get; set; }
    }

    public class Crosslinks
    {
        public List<Filter> filter { get; set; }
    }

    public class Relations
    {
        public Algorithms algorithms { get; set; }
        public Samestyledifferentlook samestyledifferentlook { get; set; }
        public Goeswellwith goeswellwith { get; set; }
        public Neededitems neededitems { get; set; }
        public Crosslinks crosslinks { get; set; }
    }

    public class Item
    {
        [JsonProperty("@key")]
        public string Key { get; set; }

        [JsonProperty("@value")]
        public string Value { get; set; }

        [JsonProperty("@link")]
        public string Link { get; set; }

        [JsonProperty("@has-local-version")]
        public string HasLocalVersion { get; set; }

        [JsonProperty("@hexcolor")]
        public string Hexcolor { get; set; }

        [JsonProperty("@lowervalue")]
        public string Lowervalue { get; set; }

        [JsonProperty("@uppervalue")]
        public string Uppervalue { get; set; }
    }

    public class Group
    {
        [JsonProperty("@key")]
        public string Key { get; set; }
        public List<Item> item { get; set; }
    }

    public class Groups
    {
        public List<Group> group { get; set; }
    }

    public class Desc
    {
        [JsonProperty("#cdata-section")]
        public string CdataSection { get; set; }
    }

    public class Product
    {
        [JsonProperty("@name")]
        public string Name { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@baseid")]
        public string Baseid { get; set; }

        [JsonProperty("@state")]
        public string State { get; set; }

        [JsonProperty("@url")]
        public string Url { get; set; }

        [JsonProperty("@col")]
        public string Col { get; set; }

        [JsonProperty("@cat")]
        public string Cat { get; set; }

        [JsonProperty("@subcol")]
        public string Subcol { get; set; }

        [JsonProperty("@subcat")]
        public string Subcat { get; set; }

        [JsonProperty("@metal")]
        public string Metal { get; set; }

        [JsonProperty("@material")]
        public string Material { get; set; }

        [JsonProperty("@color")]
        public string Color { get; set; }

        [JsonProperty("@theme")]
        public string Theme { get; set; }

        [JsonProperty("@stone")]
        public string Stone { get; set; }

        [JsonProperty("@release")]
        public string Release { get; set; }

        [JsonProperty("@price")]
        public string Price { get; set; }

        [JsonProperty("@local")]
        public string Local { get; set; }

        [JsonProperty("@pindex")]
        public string Pindex { get; set; }

        [JsonProperty("@findex")]
        public string Findex { get; set; }
        public Desc desc { get; set; }

        [JsonProperty("@newest")]
        public string Newest { get; set; }

        [JsonProperty("@range")]
        public string Range { get; set; }
    }

    public class Products
    {
        public List<Product> product { get; set; }
    }

    public class Data
    {
        [JsonProperty("@language")]
        public string Language { get; set; }

        [JsonProperty("@imageurl")]
        public string Imageurl { get; set; }

        [JsonProperty("@currency")]
        public string Currency { get; set; }

        [JsonProperty("@currency-in-prefix")]
        public string CurrencyInPrefix { get; set; }

        [JsonProperty("@decimalseparator")]
        public string Decimalseparator { get; set; }

        [JsonProperty("@thousandsseparator")]
        public string Thousandsseparator { get; set; }

        [JsonProperty("@currency-decimal-digits")]
        public string CurrencyDecimalDigits { get; set; }

        [JsonProperty("@devicefont")]
        public string Devicefont { get; set; }

        [JsonProperty("@left2right")]
        public string Left2right { get; set; }

        [JsonProperty("@ecom")]
        public string Ecom { get; set; }

        [JsonProperty("@ecomurl")]
        public string Ecomurl { get; set; }
        public Relations relations { get; set; }
        public Groups groups { get; set; }
        public Products products { get; set; }
    }

    public class PandoraRoot
    {
        public Data data { get; set; }
    }
}
