using System;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen la guarda y la retorna.
    /// </remarks>
    public class FilterSave : IFilter
    {
        // Counter es utilizado para que las imagenes tengan distintos nombres
        static public int counter = 0;

        /// Un filtro que retorna una imagen luego de ser guardada.
        /// </summary>
        /// <param name="image">La imagen la cual es guardada.</param>
        /// <returns>La misma imagen luego de ser guardada.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image, $"../Program/ModifiedImages/SavedImage{counter}.jpg");
            counter++;

            return image;
        }

    }
}