cmake_minimum_required(VERSION 3.10)
project(yoc C)

set(CMAKE_C_STANDARD 11)

add_executable(yoc main.c cli/cli.c cli/cli.h err/ncerror.c err/ncerror.h)