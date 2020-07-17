//
// Created by amin on 7/15/2020.
//

#include <stdio.h>
#include <stdlib.h>
#include "seterr.h"

//Simple display of an error
extern void set_error(char title[],char caption[] , enum erraction action )
{
    printf("[%s]:%s",title,caption);
    if(action == waitfusr)
    {
     getchar();
    }else
    {
        exit(EXIT_FAILURE);
    }
}