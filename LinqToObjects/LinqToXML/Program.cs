using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region XML
            var xml = @"
<breakfast_menu>
   <food>
      <name>Belgian Waffles</name>
      <price>$5.95</price>
      <description>Two of our famous Belgian Waffles with plenty of real maple syrup</description>
      <calories>650</calories>
   </food>
   <food>
      <name>Strawberry Belgian Waffles</name>
      <price>$7.95</price>
      <description>Light Belgian waffles covered with strawberries and whipped cream</description>
      <calories>900</calories>
   </food>
   <food>
      <name>Berry-Berry Belgian Waffles</name>
      <price>$8.95</price>
      <description>Light Belgian waffles covered with an assortment of fresh berries and whipped cream</description>
      <calories>900</calories>
   </food>
   <food>
      <name>French Toast</name>
      <price>$4.50</price>
      <description>Thick slices made from our homemade sourdough bread</description>
      <calories>600</calories>
   </food>
   <food>
      <name>Homestyle Breakfast</name>
      <price>$6.95</price>
      <description>Two eggs, bacon or sausage, toast, and our ever-popular hash browns</description>
      <calories>950</calories>
   </food>
</breakfast_menu>";
            #endregion

            var xmlDocument = XDocument.Load(xml);

            var result = (from a in xmlDocument.Descendants("food")
                          where Convert.ToDecimal(a.Element("price")
                          .Value.Replace("$","")) > 6
                          select a).ToList();

            foreach(var food in result)
            {
                Console.WriteLine(food.Element("price").Value);
                Console.WriteLine(food.Element("description").Value);
            }

            Console.ReadLine();
        }
    }
}
