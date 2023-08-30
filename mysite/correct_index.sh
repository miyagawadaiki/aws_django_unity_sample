#!/bin/bash

# テキストファイルのパス
file_path="templates/index.html"

# 冒頭に追加する文章
prepend_text="{% load static %}\n"

# 文章の追加
echo -e "${prepend_text}$(cat ${file_path})" > ${file_path}


# 入れ替える文字列
string_to_replace="Build/unity_build.loader.js"
replacement_string="{% static 'unity_build.loader.js' %}"

# 文字列の入れ替え
sed -i "" "s|${string_to_replace}|${replacement_string}|g" ${file_path}


# 入れ替える文字列
string_to_replace="Build/unity_build.data.br"
replacement_string="{% static 'unity_build.data.br' %}"

# 文字列の入れ替え
sed -i "" "s|${string_to_replace}|${replacement_string}|g" ${file_path}


# 入れ替える文字列
string_to_replace="Build/unity_build.framework.js.br"
replacement_string="{% static 'unity_build.framework.js.br' %}"

# 文字列の入れ替え
sed -i "" "s|${string_to_replace}|${replacement_string}|g" ${file_path}


# 入れ替える文字列
string_to_replace="Build/unity_build.wasm.br"
replacement_string="{% static 'unity_build.wasm.br' %}"

# 文字列の入れ替え
sed -i "" "s|${string_to_replace}|${replacement_string}|g" ${file_path}


echo "操作が完了しました。"
