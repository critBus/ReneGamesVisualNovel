/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 16:07
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Progresos;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable
{
	/// <summary>
	/// Description of CondicionDeEtapa_Ejecutable_VN.
	/// </summary>
	public class CondicionDeEtapa_Ejecutable_VN:CondicionDeEtapa_VN
	{
		private ArbolDeProgreso_VN arbolDeEventos;
		private Predicate<ArbolDeProgreso_VN> predicate;
		public CondicionDeEtapa_Ejecutable_VN(ArbolDeProgreso_VN arbolDeEventos)
		{
			this.arbolDeEventos=arbolDeEventos;
		}
		public CondicionDeEtapa_VN setCondicion(Predicate<ArbolDeProgreso_VN> p){
			this.predicate=p;
			return this;
		}
		public bool seCumple(){
			return predicate(arbolDeEventos);
		}
	}
}
