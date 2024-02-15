import { FC } from 'react';
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';

interface PortfolioArrowComponentProps {
	value: number;
}

const PortfolioArrowComponent: FC<PortfolioArrowComponentProps> = (props) => {
	return (
		<>
			{props.value > 0 &&
				<ArrowUpwardIcon sx={{ verticalAlign: 'middle' }}></ArrowUpwardIcon>
			}
			{props.value < 0 &&
				<ArrowDownwardIcon sx={{ verticalAlign: 'middle' }}></ArrowDownwardIcon>
			}
		</>
	);
};

export default PortfolioArrowComponent;
