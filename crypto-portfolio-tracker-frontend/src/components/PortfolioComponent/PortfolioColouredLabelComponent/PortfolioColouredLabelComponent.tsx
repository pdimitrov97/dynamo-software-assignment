import { FC } from 'react';
import { Box } from '@mui/material';

interface PortfolioColouredLabelComponentProps {
	value: number,
	children?: React.ReactNode
}

const PortfolioColouredLabelComponent: FC<PortfolioColouredLabelComponentProps> = (props) => {
	return (
		<Box component="span" sx={{ display: 'inline', color: (props.value >= 0 ? "green" : "red") }}>{props.children}</Box>
	);
};

export default PortfolioColouredLabelComponent;
