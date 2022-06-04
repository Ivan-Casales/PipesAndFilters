using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen la publica en twitter y la retorna.
    /// </remarks>
    public class FilterTwitter : IFilter
    {
        /// Un filtro que retorna una imagen luego de ser publicada en twitter.
        /// </summary>
        /// <param name="image">La imagen la cual es publicada.</param>
        /// <returns>La misma imagen luego de ser publicada.</returns>
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            int counter = FilterSave.counter - 1;
            Console.WriteLine(twitter.PublishToTwitter("Testeo_Twitter", $"../Program/ModifiedImages/SavedImage{counter}.jpg"));

            return image;
        }
    }
}