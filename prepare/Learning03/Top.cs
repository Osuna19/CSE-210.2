public class TopBottom
{
    private int _top;
    private int _bottom;

// Make top and bottom 1
    public TopBottom(){
        _top = 1;
        _bottom = 1;
    }
    public TopBottom (int top, int bottom){
        _top = top;
        _bottom = bottom;
    }
    //Make the top number be a whole number
      public TopBottom (int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    //Get the int into a text.
    public string GetFraction(){
        string _fraction = $"{_top}/{_bottom}";
        return _fraction; 
        }
    //Convert fraction into a decimal 
    public double GetDecimal(){
        return (double)_top / (double)_bottom;
    }
}