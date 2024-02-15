import { Button, Typography } from '@mui/material';
import React, { FC, useState } from 'react';

interface FileUploadComponentProps {
	uploadButtonName?: string;
	accept?: string
	onUploadClicked: (file: File) => {};
}

const FileUploadComponent: FC<FileUploadComponentProps> = (props) => {
	const [file, setFile] = useState<File | null>(null);

	const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		if (e.target.files) {
			setFile(e.target.files[0]);
		}
	};

	const handleUpload = async () => {
		if (file) {
			props.onUploadClicked(file);
		}
	};

	return (
		<div>
			<div>
				<input id="contained-button-file" type="file" accept={props.accept} style={{ display: "none" }} onChange={handleFileChange} />
				<label htmlFor="contained-button-file">
					<Button variant="outlined" color="primary" component="span">Choose file</Button>
				</label>
				<Button variant="contained" color="primary" sx={{ ml: 2 }} disabled={!!!file} component="span" onClick={handleUpload}>{props.uploadButtonName ?? "Upload"}</Button>
			</div>
			{file && (
				<Typography paragraph={true} sx={{ mt: 1 }} noWrap>File name: {file.name}</Typography>
			)}
		</div>
	)
};

export default FileUploadComponent;
