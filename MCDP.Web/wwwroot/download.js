window.downloadFile = (fileName, base64Data) => {
    const link = document.createElement('a');
    link.href = `data:application/pdf;base64,${base64Data}`;
    link.download = fileName;
    link.click();
};
