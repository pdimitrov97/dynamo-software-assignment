import { FC } from 'react';
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from '@mui/material';
import { PortfolioViewModel } from '../../services/portfolios/ViewModels/PortfolioViewModel';
import PortfolioChangeChartComponent from './PortfolioChangeChartComponent/PortfolioChangeChartComponent';
import formatUsCurrency from '../../utils/CurrencyFormatter';
import PortfolioColouredLabelComponent from './PortfolioColouredLabelComponent/PortfolioColouredLabelComponent';
import PortfolioArrowComponent from './PortfolioArrowComponent/PortfolioArrowComponent';
import formatPercent from '../../utils/PercentFormatter';
import formatAmount from '../../utils/AmountFormatter';

interface PortfolioComponentProps {
	portfolioViewModel: PortfolioViewModel;
}

const PortfolioComponent: FC<PortfolioComponentProps> = (props: PortfolioComponentProps) => {
	return (
		<div style={{ width: '100%' }}>
			<Typography variant="h5" noWrap>Portfolio: {props.portfolioViewModel.fileName}</Typography>

			<Typography paragraph={true} noWrap>Initial value: {formatUsCurrency(props.portfolioViewModel.entity.initialValue)}</Typography>
			<Typography paragraph={true} noWrap>Current value: {formatUsCurrency(props.portfolioViewModel.entity.currentValue)}</Typography>
			<Typography paragraph={true} noWrap>
				Overall change:&nbsp;
				<PortfolioColouredLabelComponent value={props.portfolioViewModel.entity.overallChangeValue}>
					{formatUsCurrency(props.portfolioViewModel.entity.overallChangeValue)} (&nbsp;
					<PortfolioArrowComponent value={props.portfolioViewModel.entity.overallChangePercentage}></PortfolioArrowComponent>
					{formatPercent(props.portfolioViewModel.entity.overallChangePercentage)} )
				</PortfolioColouredLabelComponent>
			</Typography>

			<Typography paragraph={true} noWrap>
				Change since open:&nbsp;
				<PortfolioColouredLabelComponent value={props.portfolioViewModel.changeValueSinceOpen}>
					{formatUsCurrency(props.portfolioViewModel.changeValueSinceOpen)} (&nbsp;
					<PortfolioArrowComponent value={props.portfolioViewModel.changePercentageSinceOpen}></PortfolioArrowComponent>
					{formatPercent(props.portfolioViewModel.changePercentageSinceOpen)} )
				</PortfolioColouredLabelComponent>
			</Typography>

			<TableContainer component={Paper}>
				<Table aria-label="Portfolio items table">
					<TableHead>
						<TableRow>
							<TableCell component="th">Coin</TableCell>
							<TableCell component="th" align="right">Amount</TableCell>
							<TableCell component="th" align="right">Buy Price</TableCell>
							<TableCell component="th" align="right">Initial Value</TableCell>
							<TableCell component="th" align="right">Current Price</TableCell>
							<TableCell component="th" align="right">Current Value</TableCell>
							<TableCell component="th" align="right">Change Since Open</TableCell>
						</TableRow>
					</TableHead>
					<TableBody>
						{props.portfolioViewModel.itemViewModels.map(item => (
							<TableRow key={item.entity.coin}>
								<TableCell scope="row">{item.entity.coin}</TableCell>
								<TableCell align="right">{formatAmount(item.entity.amount)}</TableCell>
								<TableCell align="right">{formatUsCurrency(item.entity.buyPrice)}</TableCell>
								<TableCell align="right">{formatUsCurrency(item.entity.initialValue)}</TableCell>
								<TableCell align="right">{formatUsCurrency(item.entity.currentPrice)}</TableCell>
								<TableCell align="right">
									<PortfolioColouredLabelComponent value={item.entity.changePercentage}>
										{formatUsCurrency(item.entity.currentValue)} (&nbsp;
										<PortfolioArrowComponent value={item.entity.changePercentage}></PortfolioArrowComponent>
										{formatPercent(item.entity.changePercentage)} )
									</PortfolioColouredLabelComponent>
								</TableCell>
								<TableCell align="right">
									<PortfolioColouredLabelComponent value={item.changeValueSinceOpen}>
										{formatUsCurrency(item.changeValueSinceOpen)} (&nbsp;
										<PortfolioArrowComponent value={item.changePercentageSinceOpen}></PortfolioArrowComponent>
										{formatPercent(item.changePercentageSinceOpen)} )
									</PortfolioColouredLabelComponent>
								</TableCell>
							</TableRow>
						))}
					</TableBody>
				</Table>
			</TableContainer>

			<PortfolioChangeChartComponent portfolioHistoryItems={props.portfolioViewModel.history}></PortfolioChangeChartComponent>
		</div>
	);
};

export default PortfolioComponent;
