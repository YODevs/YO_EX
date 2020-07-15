cmake_minimum_required(VERSION 3.10)
project(YOC C)

set(CMAKE_C_STANDARD 11)

add_executable(YOC main.c cli/cli.c cli/cli.h cli/parseargs.c cli/parseargs.h err/clierr.c err/clierr.h err/seterr.c err/seterr.h)