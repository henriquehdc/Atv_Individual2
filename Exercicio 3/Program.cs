using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {

			using (SKBitmap bitmapEntrada = SKBitmap.Decode("C:\\Users\\HENRIQUE.CORT\\Desktop\\ComputaçãoCognitiva\\Atv2\\Atv_Individual2\\Exercicio 3\\entrada\\Exercicio 3.png")){
				
				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();		

					int largura = bitmapEntrada.Width;
					int altura = bitmapEntrada.Height;
					int pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;
					int [] pixels= new int[256];
                    int pixelsContados = 0;

					for (int y = 0; y < altura ; y++) {
						for (int x= 0; x < largura ; x++) {
							pixels[entrada[y * largura + x ]] += 1;
						}
					}

                    for (int z=0; z<=255; z++){
                        Console.WriteLine("Quantidade de pixels com valor "+ z +": "+ pixels[z]);
                        pixelsContados += pixels[z];
                    }   
                    Console.WriteLine("Pixels Totais: " + pixelsTotais);
                    Console.WriteLine("Pixels contados: " + pixelsContados);
                }
			}
		}
	}
}
