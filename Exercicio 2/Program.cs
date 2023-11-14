using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("C:\\Users\\HENRIQUE.CORT\\Desktop\\ComputaçãoCognitiva\\Atv2\\Atv_Individual2\\Exercicio 2\\entrada\\lenna.png"),
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8))) {
					
				static void AlteraBrilho(byte r, byte g, byte b, out byte saida) {
					unsafe{
						double R = (double)r / 255.0;
						double G = (double)g / 255.0;
						double B = (double)b / 255.0;

						double max = Math.Max(Math.Max(R, G), B);
						double V = max;

						double v =255.0 * V;
						saida = 0;
						if (v < 0){
							saida = (byte)(saida * (1 + v));
						}else{
							saida = (byte)(saida + ((255 - saida) * v));
						}	

						if(saida < 0){
							saida = 0;
						}
						if(saida > 255){
							saida = 255;
						}	
					}							
				}

					unsafe {
						byte* entrada = (byte*)bitmapEntrada.GetPixels();
						byte* saida = (byte*)bitmapSaida.GetPixels();

						int largura = bitmapEntrada.Width;
						int altura = bitmapEntrada.Height;
						long pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;

						unsafe{
							for (int e = 0, s = 0; s < pixelsTotais; e += 4, s++) {
								AlteraBrilho(entrada[e + 2] , entrada[e + 1] , entrada[e], out saida[s]) ;
							}
						}							
					}
					unsafe{
						using (FileStream stream = new FileStream("C:\\Users\\HENRIQUE.CORT\\Desktop\\ComputaçãoCognitiva\\Atv2\\Atv_Individual2\\Exercicio 2\\saida\\Exercicio2Saida.png", FileMode.OpenOrCreate, FileAccess.Write)) {
							bitmapSaida.Encode(stream, SKEncodedImageFormat.Png, 100);
						}
					}
			}	
		}
	}
}
