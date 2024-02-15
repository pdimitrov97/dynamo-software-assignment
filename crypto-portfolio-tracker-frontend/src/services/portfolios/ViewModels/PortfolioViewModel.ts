import { Portfolio } from "../Models/Portfolio";
import { PortfolioItemViewModel } from "./PortfolioItemViewModel";
import { ISupportHistory } from "./ISupportHistory";
import { ISupportChangeSinceOpen } from "./ISupportChangeSinceOpen";

export interface PortfolioViewModel extends ISupportHistory<Portfolio>, ISupportChangeSinceOpen {
	entity: Portfolio;
	fileName: string
	itemViewModels: PortfolioItemViewModel[];
}