import { PortfolioItem } from "../Models/PortfolioItem";
import { ChangeSinceOpenHelper } from "./ChangeSinceOpenHelper";
import { HistoryItemHelper } from "./HistoryItemHelper";
import { PortfolioItemViewModel } from "./PortfolioItemViewModel";

export class PortfolioItemViewModelHelper {
	public static createPortfolioItemViewModel(entity: PortfolioItem): PortfolioItemViewModel {
		return {
			entity: entity,
			history: [HistoryItemHelper.createHistoryPortfolioItem(entity)],
			changeValueSinceOpen: 0,
			changePercentageSinceOpen: 0
		};
	}

	public static updatePortfolioItemViewModels(portfolioItemViewModels: PortfolioItemViewModel[], updatedPortfolioItems: PortfolioItem[]): PortfolioItemViewModel[] {
		const result: PortfolioItemViewModel[] = [];

		for (const updatedPortfolioItem of updatedPortfolioItems) {
			const currentViewModel = portfolioItemViewModels.find(x => x.entity.coin === updatedPortfolioItem.coin);

			if (currentViewModel) {
				result.push(PortfolioItemViewModelHelper.updatePortfolioItemViewModel(currentViewModel, updatedPortfolioItem));
			}
			else {
				result.push(PortfolioItemViewModelHelper.createPortfolioItemViewModel(updatedPortfolioItem));
			}
		}

		return result;
	}

	public static updatePortfolioItemViewModel(portfolioItemViewModel: PortfolioItemViewModel, updatedPortfolio: PortfolioItem): PortfolioItemViewModel {
		const newHistory = [...portfolioItemViewModel.history, HistoryItemHelper.createHistoryPortfolioItem(updatedPortfolio)];
		const newPortfolioItemVm = {
			...portfolioItemViewModel,
			entity: updatedPortfolio,
			history: newHistory,
			...ChangeSinceOpenHelper.calculateChangeSinceOpen(newHistory)
		};

		return newPortfolioItemVm;
	}
}