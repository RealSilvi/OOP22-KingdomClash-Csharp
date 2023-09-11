
namespace AbdoulayeKane;

public class CityConfiguration
{
   private readonly int DefaultRows = 5;
   private readonly int DefaultColums = 5;

   private readonly int width;
   private readonly int height;
   

   public CityConfiguration()
   {
      width = DefaultColums;
      height = DefaultRows;

   }

   public int GetHeight()
   {
      return width;
   }

   public int GetWidth()
   {
      return height;
   }
}