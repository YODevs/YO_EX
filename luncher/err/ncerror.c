//
// Created by Amin Badin [@AminCoder] on 7/21/2020.
// Cv : www.AminCoder.ir
// Mail : dev@yo-lang.org
// Repository : https://github.com/YODevs/YO
// Official Website : www.yo-lang.org
//

#include <stdio.h>
#include <stdlib.h>
#include "ncerror.h"

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