import { FC } from 'react';
import { LineChart } from '@mui/x-charts';
import { Typography } from '@mui/material';
import formatTime from '../../../utils/TimeFormatter';
import formatUsCurrency from '../../../utils/CurrencyFormatter';
import { HistoryPortfolio } from '../../../services/portfolios/ViewModels/HistoryPortfolio';

interface PortfolioChangeChartComponentProps {
	portfolioHistoryItems: HistoryPortfolio[];
}

const PortfolioChangeChartComponent: FC<PortfolioChangeChartComponentProps> = (props: PortfolioChangeChartComponentProps) => {
	return (
		<div>
			<Typography variant="h5" noWrap sx={{ mt: 4 }}>Portfolio overall change:</Typography>
			<LineChart
				xAxis={[{ data: props.portfolioHistoryItems.map(x => x.timestamp), scaleType: 'time', valueFormatter: formatTime }]}
				yAxis={[{ valueFormatter: formatUsCurrency }]}
				margin={{ left: 100 }}
				series={[{ data: props.portfolioHistoryItems.map(hi => hi.item.currentValue), valueFormatter: formatUsCurrency }]}
				height={400}
			/>
		</div>
	);
};

export default PortfolioChangeChartComponent;
