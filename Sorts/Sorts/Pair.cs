namespace Sorts
{
    class Pair
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Pair(int key = 0, string val = "")
        {
            Key = key;
            Value = val;
        }
    }
}
