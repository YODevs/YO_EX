cmake_minimum_required(VERSION 3.10)
project(Luncher C)

set(CMAKE_C_STANDARD 11)

add_executable(Luncher main.c cli/cli.c cli/cli.h)