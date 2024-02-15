import { Portfolio } from "../Models/Portfolio";
import { PortfolioItem } from "../Models/PortfolioItem";
import { HistoryPortfolio } from "./HistoryPortfolio";
import { HistoryPortfolioItem } from "./HistoryPortfolioItem";

export class HistoryItemHelper {
	public static createHistoryPortfolio(portfolio: Portfolio): HistoryPortfolio {
		return {
			item: portfolio,
			timestamp: new Date()
		};
	}

	public static createHistoryPortfolioItem(portfolioItem: PortfolioItem): HistoryPortfolioItem {
		return {
			item: portfolioItem,
			timestamp: new Date()
		};
	}
}