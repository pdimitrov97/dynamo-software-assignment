import Apis from "../Apis";
import { Portfolio } from "./Models/Portfolio";

class PortfolioService {

	public async calculateValue(portfolioFile: File): Promise<Portfolio> {
		const formData = new FormData();
		formData.append("portfolioFile", portfolioFile);

		return fetch(`${Apis.portfolioApi}/v1/portfolios/calculate-value`, { method: "POST", headers: { "Accept": "application/json" }, body: formData })
			.then(response => {
				if (!response.ok) {
					return response.json().then(ex => {
						throw new Error(ex.message);
					})
				}

				return response.json() as Promise<Portfolio>
			});
	}
}

export let httpService = new PortfolioService();