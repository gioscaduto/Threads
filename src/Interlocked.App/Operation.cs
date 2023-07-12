namespace Interlocked.App
{
    public class Operation
    {

        private int value;
        public int Value => value;

        public void Increment()
        {
            //value++;
            System.Threading.Interlocked.Increment(ref value);
        }

        public void SetValue(int newValue)
        {
            //value = newValue;
            System.Threading.Interlocked.Exchange(ref value, newValue);
        } 

        public void CompareAndChange(int compare, int newValue)
        {
            //if (Value == compare)
            //{
            //    value = newValue;
            //}                
            System.Threading.Interlocked.CompareExchange(ref value, newValue, compare);
        }
    }
}
