#! /bin/bash
pip install -r ./celt2/server/requirements.txt
pip install -r ./celt2/model/requirements.txt -f https://download.pytorch.org/whl/lts/1.8/torch_lts.html
chmod +x ./celt2/API/setup.sh
./celt2/API/setup.sh
