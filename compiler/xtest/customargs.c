//
// Created by Amin Badin on 7/15/2020.
// Cv : www.AminCoder.ir
// Rep : https://github.com/YODevs/YO
//

#include <stdio.h>
#include <mem.h>
#include "customargs.h"
#include "../cli/parseargs.h"

//Max command space.
#define MAXARGCOUNT 10
extern void set_custom_argument(char command[])
{
    char * argval[MAXARGCOUNT];
    short int nargval = 0;
    char commandinject[strlen(command)];
    strcpy(commandinject,command);
    char * pstrtoken;
    //command to token by split spaces.
    pstrtoken = strtok(commandinject," ");
    while (pstrtoken != NULL)
    {
        argval[nargval] = pstrtoken;
        pstrtoken = strtok(NULL, " ");
        if(pstrtoken != NULL)
            nargval++;
    }
    //invoke parse_args
    parse_args(nargval ,argval);
    return;
}