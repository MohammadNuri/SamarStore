using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Products;

namespace SamarStore.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(Ordering ordering,string? searchKey, long? catId , int page, int pageSize);
    }

	public enum Ordering
	{

		NotOrder = 0,
		/// <summary>
		/// پربازدیدترین
		/// </summary>
		MostVisited = 1,
		/// <summary>
		/// پرفروشترین
		/// </summary>
		Bestselling = 2,
		/// <summary>
		/// محبوبترین
		/// </summary>
		MostPopular = 3,
		/// <summary>
		/// جدیدترین
		/// </summary>
		theNewest = 4,
		/// <summary>
		/// ارزانترین
		/// </summary>
		Cheapest = 5,
		/// <summary>
		/// گرانترین
		/// </summary>
		theMostExpensive = 6
	}

}
