/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 15:40
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Dialogo;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable 
{
	/// <summary>
	/// Description of CondicionDeVisbilidadDeOpcion_Ejecutable_VN.
	/// </summary>
	public class CondicionDeVisbilidadDeOpcion_Ejecutable_VN:CondicionDeVisbilidadDeOpcion_VN
	{
		public  Predicate<ContextoDeDialogo_VN> Condicion;
		
		public CondicionDeVisbilidadDeOpcion_Ejecutable_VN(Predicate<ContextoDeDialogo_VN> condicion)
		{
			this.Condicion=condicion;
		}
		
		public virtual bool seCumple(ContextoDeDialogo_VN contexto){
			return this.Condicion(contexto);
		}
	}
}
