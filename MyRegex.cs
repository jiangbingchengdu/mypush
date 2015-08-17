
void Main()
{
    string[] ary=
        {
            @"<img src=""/img/01.jpg"" />",
            @"<img class=""c1 c2"" src=""/img/01.jpg"" />",
            @"<img src=""/img/01.jpg"" class=""c1 c2"" />",
            @"<img class=""c1 c2"" src=""/img/01.jpg"" />",
            @"<img data-other=""abc"" class=""c1 c2"" src=""/img/01.jpg"" />",
            @"<img class=""c1 c2"" data-other=""abc"" src=""/img/01.jpg"" />"
        };
    Regex regSimple=new Regex(@"(?i)<img\b[^>]*?src\s*=(['""]?)(?<src>[^'""]+)\1[^>]*?>");
    Regex reg=new Regex(@"(?i)<img\b(?=[^>]*?src\s*=(['""]?)(?<src>[^'""]+)\1)[^>]*?(class\s*=(['""]?)(?<class>[^'""]+)\3)[^>]*?>");
    foreach(string s in ary)
    { 
        if(reg.IsMatch(s))
        {
            Match m =reg.Match(s);
            Console.WriteLine("{0}\t{1}",m.Groups["src"].Value,m.Groups["class"].Value);
        }
        else
        {
               Match m =regSimple.Match(s);
            Console.WriteLine("{0}",m.Groups["src"].Value);
        }
    }
}
/*
/img/01.jpg
/img/01.jpg    c1 c2
/img/01.jpg    c1 c2
/img/01.jpg    c1 c2
/img/01.jpg    c1 c2
/img/01.jpg    c1 c2
*/