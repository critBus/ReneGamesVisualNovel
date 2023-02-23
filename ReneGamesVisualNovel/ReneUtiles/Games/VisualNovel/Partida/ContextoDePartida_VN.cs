/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 14:24
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Personajes;
namespace ReneUtiles.Games.VisualNovel.Partida
{
	/// <summary>
	/// Description of ContextoDePartida_VN.
	/// </summary>
	public class ContextoDePartida_VN
	{
		public ArbolDeProgreso_VN Progreso;
		
		public PersonajePrincipal_VN PersonajePrincipal;
		public ContextoDePartida_VN(ArbolDeProgreso_VN progreso,PersonajePrincipal_VN personajePrincipal)
		{
			this.Progreso=progreso;
			this.PersonajePrincipal=personajePrincipal;
		}
		
		public bool seHaProgresadoHasta(Etapa_VN e){
			return Progreso.seHaProgresadoHasta(e);
		}
	}
}
