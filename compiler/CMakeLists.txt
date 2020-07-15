cmake_minimum_required(VERSION 3.10)
project(YOCompiler C)

set(CMAKE_C_STANDARD 11)

add_executable(YOCompiler main.c cli/cli.c cli/cli.h)