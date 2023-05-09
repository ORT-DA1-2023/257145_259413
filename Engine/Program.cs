using Domain;
using Engine;
using System;

Scene scene = new Scene();

Figure figure = new Figure("prueba", 0.5);

Material material = new Material("prueba", System.Drawing.Color.FromArgb(50,40,30));

Model model = new Model("prueba", figure, material);

Coordinate position = new Coordinate(0,2,5);

PositionedModel positionedModel = new PositionedModel(model, position);

scene.addPositionedModel(positionedModel);

Render render = new Render(scene);
//render.RenderScene();













/*int resolutionX = 200;
int resolutionY = 100;

Vector[][] pixels = new Vector[resolutionX][];
for(int i = 0; i< resolutionX; i++)
{
    pixels[i] = new Vector[resolutionY];
}

for(int row = resolutionY-1; row >= 0; row--)
{
    for(int column = 0; column < resolutionX; column++)
        {
        double red = (double)column/resolutionX;
        double green = (double)row/resolutionY;
        double blue = 0.2;
        Vector pixelRGB = new Vector(red, green, blue);
        savePixel(row, column, pixelRGB, resolutionY, pixels);
    }
}

string fileName = "D:\\reposvs\\Obligatorio\\Engine\\1-imagen-ppm.ppm";

string imageString = "P3\n" + resolutionX + " " + resolutionY + "\n255\n";
            
for(int j = 0; j < resolutionY;  j++)
{
    for (int i = 0; i < resolutionX; i++)
    {
        Vector color = pixels[i][j];
        imageString += color.Red() + " " + color.Green() + " " + color.Blue() + "\n";
    }
}

File.WriteAllText(fileName,imageString);
        



void savePixel(int row, int column, Vector pixelRGB, int resolutionY, Vector[][] pixels)
{
    int posX = column;
    int posY = resolutionY - row - 1;
    if(posY < resolutionY)
    {
        pixels[posX][posY] = pixelRGB;
    }
    else
    {
        throw new Exception("Pixel Overflow Error");
    }
}*/
