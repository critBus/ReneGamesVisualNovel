/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 5/5/2022
 * Hora: 15:06
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneUtiles.Clases;
namespace ReneUtiles.Games.VisualNovel.Progresos
{
	/// <summary>
	/// Description of BosqueDeEventos.
	/// </summary>
	public class ArbolDeProgreso_VN
	{
		public List<Progreso_VN> ListaDeProgresos;
		public ArbolDeProgreso_VN()
		{
			this.ListaDeProgresos=new List<Progreso_VN>();
		}
		
		public Progreso_VN newProgreso(string nombre,string descripcion=null){
			Progreso_VN p=new Progreso_VN(this,nombre,descripcion);
			ListaDeProgresos.Add(p);
			return p;
		}
		
		public Progreso_VN getProgreso(string nombre){
			foreach(Progreso_VN e in ListaDeProgresos){
				if(e.Nombre==nombre){
					return e;
				}
			}
			return null;
		}
		
		public bool seHaProgresadoHasta(Etapa_VN e){
			foreach(Progreso_VN p in ListaDeProgresos ){
				if(p.seHaProgresadoHasta(e)){
					return true;
				}
			}
			return false;
		}
		
	}
}
