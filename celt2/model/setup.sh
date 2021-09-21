#! /bin/bash

echo -e "\033[0;31mDownloading stanford-corenlp, this may take a while...\033[0;37m"
wget -O stanford-corenlp.zip 'https://nlp.stanford.edu/software/stanford-corenlp-4.2.2.zip'
echo -e "\033[0;31mUnzipping stanford-corenlp\033[0;37m"
unzip stanford-corenlp.zip
echo -e "\033[0;31mDeleting the stanford-corenlp.zip file - the unzipped contents will remain\033[0;37m"
rm -rf ./stanford-corenlp.zip
echo -e "\033[0;32mSetup complete!\033[0;37m"
