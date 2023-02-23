/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 5/5/2022
 * Hora: 15:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
namespace ReneUtiles.Games.VisualNovel.Progresos
{
	/// <summary>
	/// Description of Evento_VN.
	/// </summary>
	public class Etapa_VN:Condicional
	{
		public CondicionDeEtapa_VN CondicionDeInicio;
		public DescripcionDeEstado_VN DescripcionDeEstado; 
		
		public string Nombre,Descripcion;
		
		public bool Completado;
		
		private bool usarLenguajeDescriptivo = true;
		
		public Etapa_VN(string nombre,string descripcion)
		{
			this.Nombre=nombre;
			this.Descripcion=descripcion;
			this.Completado=false;
		}
		
		public override string ToString()
		{
			return Nombre+": "+Descripcion;
			//return string.Format("[Etapa_VN CondicionDeInicio={0}, DescripcionDeEstado={1}, Nombre={2}, Descripcion={3}, Completado={4}]", CondicionDeInicio, DescripcionDeEstado, Nombre, Descripcion, Completado);
		}

	}
}
