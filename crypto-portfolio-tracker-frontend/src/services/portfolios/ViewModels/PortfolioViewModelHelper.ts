import { Portfolio } from "../Models/Portfolio";
import { PortfolioViewModel } from "./PortfolioViewModel";
import { HistoryItemHelper } from "./HistoryItemHelper";
import { PortfolioItemViewModelHelper } from "./PortfolioItemViewModelHelper";
import { ChangeSinceOpenHelper } from "./ChangeSinceOpenHelper";

export class PortfolioViewModelHelper {
	public static createPortfolioViewModel(entity: Portfolio, fileName: string): PortfolioViewModel {
		return {
			entity: entity,
			fileName: fileName,
			itemViewModels: entity.items.map(x => PortfolioItemViewModelHelper.createPortfolioItemViewModel(x)),
			history: [HistoryItemHelper.createHistoryPortfolio(entity)],
			changeValueSinceOpen: 0,
			changePercentageSinceOpen: 0
		};
	}

	public static updatePortfolioViewModel(viewModel: PortfolioViewModel, updatedPortfolio: Portfolio): PortfolioViewModel {
		const newHistory = [...viewModel.history, HistoryItemHelper.createHistoryPortfolio(updatedPortfolio)]
		const newPortfolioVm = {
			...viewModel,
			entity: updatedPortfolio,
			itemViewModels: PortfolioItemViewModelHelper.updatePortfolioItemViewModels(viewModel.itemViewModels, updatedPortfolio.items),
			history: newHistory,
			...ChangeSinceOpenHelper.calculateChangeSinceOpen(newHistory)
		};

		return newPortfolioVm;
	}
}