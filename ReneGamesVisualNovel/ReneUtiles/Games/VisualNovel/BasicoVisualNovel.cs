/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 15:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases;
using ReneUtiles.Games.VisualNovel.Dialogo;
using ReneUtiles.Games.VisualNovel.Dialogo.Creadores;
using ReneUtiles.Games.VisualNovel.Visualizacion;
using ReneUtiles.Games.VisualNovel.Visualizacion.Creadores;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo;
using ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable;
using ReneUtiles.Clases.Condicionales;
namespace ReneUtiles.Games.VisualNovel
{
	/// <summary>
	/// Description of BasicoVisualNovel.
	/// </summary>
	public abstract class BasicoVisualNovel:ConsolaBasica
	{
		private bool usarLenguajeDescriptivo = true;
		public  ElementoDeListaDeDialogo_VN eld(string texto,CreadorDeEscenario_VN siguiente){
			ElementoDeListaDeDialogo_VN e=new ElementoDeListaDeDialogo_VN(texto);
			e.TrasicionASiguienteElemento=new TransicionDeDialogo_VN(ctx=>siguiente.crearEscenario());
			return e;
		}
		public  ElementoDeListaDeDialogo_VN eld(string texto,CreadorDeEscenario_VN siguiente,Etapa_VN reqisitoMinimo){
			ElementoDeListaDeDialogo_VN e=eld(texto,siguiente);
			
			if(usarLenguajeDescriptivo){
				e.Condicion=new CondicionDeVisbilidadDeOpcion_Descriptiva_VN(reqisitoMinimo);
			}else{
				e.Condicion=new CondicionDeVisbilidadDeOpcion_Ejecutable_VN(ctx=>ctx.ContextoDePartida.seHaProgresadoHasta(reqisitoMinimo));
			}
			
			return e;
		}
		
		
	}
}
