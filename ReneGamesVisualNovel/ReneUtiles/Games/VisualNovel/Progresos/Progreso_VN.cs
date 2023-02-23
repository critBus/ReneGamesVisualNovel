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
using ReneUtiles.Clases.Condicionales;


using ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo;
using ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable;

using ReneUtiles.Clases.LeguajeDescritivo.Metodos;
namespace ReneUtiles.Games.VisualNovel.Progresos
{
	/// <summary>
	/// Description of ArbolDeEventos.
	/// </summary>
	public class Progreso_VN:ConsolaBasica
	{
		public string Nombre, Descripcion;
		
		private List<Etapa_VN> listaDeEventos;
		private int indiceEventoActual;
		
		
		private ArbolDeProgreso_VN arbolDeEventos;
		
		private bool usarLenguajeDescriptivo = true;
		
		public Progreso_VN(ArbolDeProgreso_VN arbolDeEventos, string nombre, string descripcion = null)
		{
			this.arbolDeEventos = arbolDeEventos;
			this.Nombre = nombre;
			this.Descripcion = descripcion ?? "";
			this.indiceEventoActual = 0;
			this.listaDeEventos = new List<Etapa_VN>();
		}
		
		public Etapa_VN getEtapaActual()
		{
			if (indiceEventoActual > -1 && indiceEventoActual < listaDeEventos.Count) {
				Etapa_VN actual = listaDeEventos[indiceEventoActual];
				return actual;
			}
			
			return null;
		}
		//		private void ponerCondicionDeInicio(){}
		
		public Etapa_VN addEtapa(string nombre, string descripcion = null)
		{
			if (!usarLenguajeDescriptivo) {
				throw new Exception("Hay que usar un leguaje ejecutable");
			}
			Etapa_VN e = new Etapa_VN(nombre: nombre, descripcion: descripcion);
			
			listaDeEventos.Add(e);
			return e;
		}
		public Etapa_VN addEtapa(string nombre, string descripcion , Condicional condicionDeInicio )
		{
//			if (!usarLenguajeDescriptivo) {
//				throw new Exception("Hay que usar un leguaje ejecutable");
//			}
//			Etapa_VN e = new Etapa_VN(nombre: nombre, descripcion: descripcion);
			Etapa_VN e =addEtapa(nombre,descripcion);
			if (usarLenguajeDescriptivo) {
				e.CondicionDeInicio = new CondicionDeEtapa_Descriptiva_VN(condicionDeInicio ?? new TRUE_Condicional());
			}
//			listaDeEventos.Add(e);
			return e;
		}
		
		public Etapa_VN addEtapa(string nombre, string descripcion , Predicate<ArbolDeProgreso_VN> condicionDeInicio )
		{
//			if (usarLenguajeDescriptivo) {
//				throw new Exception("Hay que usar un leguaje descriptivo");
//			}
//			Etapa_VN e = new Etapa_VN(nombre: nombre, descripcion: descripcion);
			
			
			Etapa_VN e =addEtapa(nombre,descripcion);
			e.CondicionDeInicio = new CondicionDeEtapa_Ejecutable_VN(this.arbolDeEventos).setCondicion(condicionDeInicio ?? (av => true));
//			listaDeEventos.Add(e);
			return e;
			
		}
		
		/// <summary>
		/// da por terminada a la etapa actual, pero recordar que una etapa
		/// este terminada no grantiza que comienze la siguiente
		/// plq para avanzar tambien tiene que cumplirse su condicion de incio
		/// </summary>
		/// <returns>bool si avanza a la siguiente etapa (si es que hay)</returns>
		public bool intentarProgresar()
		{
			Etapa_VN actual = getEtapaActual();
			if (actual != null) {
				actual.Completado = true;
			
			
			
				bool esELUtltimo = indiceEventoActual == listaDeEventos.Count - 1;
				if ((!esELUtltimo)) {
					Etapa_VN siguiente = listaDeEventos[indiceEventoActual + 1];
					if (((CondicionDeEtapa_Ejecutable_VN)siguiente.CondicionDeInicio).seCumple()) { 
						actual = siguiente;
						indiceEventoActual++;
						cwl(this.Nombre + "-> " + actual);
						return true;
					}
				}
			
			}
			
			return false;
		}
		
		public Etapa_VN getEtapa(string nombre)
		{
			foreach (Etapa_VN e in listaDeEventos) {
				if (e.Nombre == nombre) {
					return e;
				}
			}
			return null;
		}
		
		public bool seHaProgresadoHasta(Etapa_VN e)
		{
			Etapa_VN etapa = getEtapa(e.Nombre);
			if (etapa != null) {
				int indice = listaDeEventos.IndexOf(etapa);
				return indice <= indiceEventoActual;
				//return indiceEventoActual <= indice;
			}
			
			return false;
		}
		
	}
}


//if (indiceEventoActual > -1 && indiceEventoActual < listaDeEventos.Count) {
//				Etapa_VN actual = listaDeEventos[indiceEventoActual];
//				if (actual.Completado) {
//					bool esELUtltimo = indiceEventoActual == listaDeEventos.Count - 1;
//					if ((!esELUtltimo)) {
//						Etapa_VN siguiente = listaDeEventos[indiceEventoActual + 1];
//						if (siguiente.CondicionDeInicio.seCumple()) {
//							actual = siguiente;
//							indiceEventoActual++;
//						}
//					}
//				}
//
//				return actual;
//			}

/// <summary>
/// aunque se este en una etapa, su inicio (ejecuion) depende de la condicion de incio
/// </summary>
/// <summary>
/// --- no no ---
/// da por terminada a la etapa actual, pero recordar que una etapa
/// este terminada no grantiza que comienze la siguiente
/// plq para avanzar tambien tiene que cumplirse su condicion de incio
/// --- no no ---
/// </summary>

//			if(condicionDeInicio==null){
//				condicionDeInicio=av=>true;
//			}
