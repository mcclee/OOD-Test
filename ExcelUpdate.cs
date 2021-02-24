using System.Collections.Generic;
class Element{
    public int row{get; set;}
    public int col{get; set;}
    public int value{get; set;}

    public Element(int r, int c, int val=0){
        row = r;
        col = c;
        value = val;
        binding = new List<Element>();
    }
    private List<Element> binding;

    public void Update(int val){
        value += val;
        foreach(var ele in binding){
            ele.Update(val);
        }
    }

    public void AddChild(Element e){
        binding.Add(e);
    }
    public void equalty(List<Element> eles){
        foreach(var e in eles){
            e.AddChild(this);
            value += e.value;
        } 
    }

    public override string ToString(){
        return value.ToString();
    }
    public void Modify(int val){
        Update(val - value);
    }
}



