using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeForkConditional : IPipe
    {
        IPipe Pipe1;
        IPipe Pipe2;
        
        /// <summary>
        /// La cañería recibe una imagen, utiliza un filtro condicional, y dependiendo de
        ///     este, la envía a una cañeria u otra.
        /// </summary>
        /// <param name="pipe1"> Cañeria opción 1</param>
        /// <param name="pipe2"> Cañeria opción 2</param>
        public PipeForkConditional(IPipe pipe1, IPipe pipe2) 
        {
            this.Pipe1 = pipe1;
            this.Pipe2 = pipe2;           
        }
        
        /// <summary>
        /// La cañeria utiliza el FilterFaceConditional para verificar si la imagen 
        ///     ingresada tiene una cara, y respecto al atributo Face del filtro, envía
        ///     la imagen a una u otra cañeria.
        /// </summary>
        /// <param name="picture">Imagen a filtrar y enviar a la siguiente cañería</param>
        public IPicture Send(IPicture picture)
        {
            FilterFaceConditional filter = new FilterFaceConditional();
            filter.Filter(picture);
            if (filter.Face == true)
            {
                return this.Pipe1.Send(picture);
            }
            else
            {
                return this.Pipe2.Send(picture);
            }
        }
    }
}
