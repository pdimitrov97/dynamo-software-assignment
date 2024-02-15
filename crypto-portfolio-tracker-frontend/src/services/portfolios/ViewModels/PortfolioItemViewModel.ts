import { PortfolioItem } from "../Models/PortfolioItem";
import { ISupportChangeSinceOpen } from "./ISupportChangeSinceOpen";
import { ISupportHistory } from "./ISupportHistory";

export interface PortfolioItemViewModel extends ISupportHistory<PortfolioItem>, ISupportChangeSinceOpen {
	entity: PortfolioItem;
}