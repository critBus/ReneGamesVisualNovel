/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 16:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Partida; 
using ReneUtiles.Games.VisualNovel.Visualizacion.Dialogos;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable
{
	/// <summary>
	/// Description of CondicionDeVisbilidadDeDialogo_Ejecutable_VN.
	/// </summary>
	public class CondicionDeVisbilidadDeDialogo_Ejecutable_VN:CondicionDeVisbilidadDeDialogo_VN
	{
		public  Predicate<ContextoDePartida_VN> Condicion; 
		public CondicionDeVisbilidadDeDialogo_Ejecutable_VN()
		{
		}
	}
}
