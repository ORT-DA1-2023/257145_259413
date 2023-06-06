window.downloadFile = (url) => {
    // Create a temporary anchor element
    const link = document.createElement('a');
    link.href = url;
    link.download = '';

    // Trigger the click event to start the download
    link.dispatchEvent(new MouseEvent('click'));
}

