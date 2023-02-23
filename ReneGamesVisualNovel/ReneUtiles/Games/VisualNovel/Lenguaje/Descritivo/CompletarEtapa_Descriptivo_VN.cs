/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 16:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.LeguajeDescritivo.Metodos;
using ReneUtiles.Games.VisualNovel.Progresos;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo
{
	/// <summary>
	/// Description of CompletarEtapa_Descriptivo_VN.
	/// </summary>
	public class CompletarEtapas_Descriptivo_VN:Algoritmo
	{
		public Etapa_VN[] Etapas;
		public CompletarEtapas_Descriptivo_VN(params Etapa_VN[] etapas):base()
		{
			this.Etapas=etapas;
		}
	}
}
