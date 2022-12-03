 % Bibliotecas HTTP
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/http_client)).
:- use_module(library(http/http_open)).
:- use_module(library(http/http_cors)).




% Bibliotecas JSON
:- use_module(library(http/json_convert)).
:- use_module(library(http/http_json)).
:- use_module(library(http/json)).




%Servidor

startServer(Port) :-
    http_server(http_dispatch, [port(Port)]),
    asserta(port(Port)).



stopServer:-
    retract(port(Port)),
    http_stop_server(Port,_).



%armazemPrincipalID(5).
%idArmazem(<local>,<codigo>)
idArmazem('Arouca',1).
idArmazem('Espinho',2).
idArmazem('Gondomar',3).
idArmazem('Maia',4).
idArmazem('Matosinhos',5).
/*
idArmazem('Oliveira de Azemeis',6).
idArmazem('Paredes',7).
idArmazem('Porto',8).
idArmazem('Povoa de Varzim',9).
idArmazem('Santa Maria da Feira',10).
idArmazem('Santo Tirso',11).
idArmazem('Sao Joao da Madeira',12).
idArmazem('Trofa',13).
idArmazem('Vale de Cambra',14).
idArmazem('Valongo',15).
idArmazem('Vila do Conde',16).
idArmazem('Vila Nova de Gaia',17).
*/


%distancia entre cidades
%tmepo(armzem1, armazem2, distancia)
distancia(1,2,122).
distancia(1,3,122).
distancia(1,4,151).
distancia(1,5,147).
/*
distancia(1,6,74).
distancia(1,7,116).
distancia(1,8,141).
distancia(1,9,185).
distancia(1,10,97).
distancia(1,11,164).
distancia(1,12,76).
distancia(1,13,174).
distancia(1,14,59).
distancia(1,15,132).
distancia(1,16,181).
distancia(1,17,128).
*/

distancia(2, 1,116).	
distancia(2, 3,55).	
distancia(2, 4,74).	
distancia(2, 5,65).	
/*
distancia(2, 6,69).	
distancia(2, 7,74).	
distancia(2, 8,61).	
distancia(2, 9,103).	
distancia(2, 10,36).	
distancia(2, 11,88).	
distancia(2, 12,61).	
distancia(2, 13,95).	
distancia(2, 14,78).	
distancia(2, 15,69).	
distancia(2, 16,99).	
distancia(2, 17,46).
*/
distancia(3,1,120).	
distancia(3,2,50).		
distancia(3,4,46).	
distancia(3,5,46).	


distancia(4,1, 149).
distancia(4,2,65).	
distancia(4,3,46).	
distancia(4,5,27).	

distancia(5,1,141).
distancia(5,2,55).
distancia(5,3,48).
distancia(5,4,25).
/*distancia(5,6, 97).*/



%entrega(<idEntrega>,<data>,<massaEntrefa>,<armazemEntrega>,<distanciaColoc>,<distanciaRet>)
entrega(4439, 20221205, 200, 1, 8, 10).
entrega(4439, 20221205, 100, 2, 8, 10).
entrega(4439, 20221205, 400, 3, 8, 10).
entrega(4439, 20221205, 500, 4, 8, 10).

entrega(4439, 20221205, 200, 6, 8, 10).
entrega(4439, 20221205, 200, 7, 8, 10).
entrega(4438, 20221205, 150, 9, 7, 9).
entrega(4445, 20221205, 100, 3, 5, 7).
entrega(4443, 20221205, 120, 8, 6, 8).
entrega(4449, 20221205, 300, 11, 15, 20).




:- http_handler('/lapr5', responde_ola, []).




responde_ola(_Request) :-
        format('Content-type: text/plain~n~n'),
        format('Olá LAPR5!~n').



%HeuristcaMenorDistancia
bestfsDistancia(ListaArmazens, Final):- ArmazemAtual is 5,
    bestfs1(ListaArmazens, [ArmazemAtual], CaminhoFinal), 
    append(CaminhoFinal, [5], Final).

bestfs1([],Cam, CaminhoFinal):-  !,
    reverse(Cam, CaminhoFinal).

bestfs1(ListaArmazens, Cam, CaminhoFinal):-
    Cam = [ArmazemAtual|_],
    findall((CX,[X| Cam]), 
    (distancia(ArmazemAtual,X,CX), idArmazem(_,X), member(X, ListaArmazens)),
    Novos),

    sort(Novos,NovosOrd),
   
    NovosOrd = [(_,[Atual|_])|_],
    
    delete(ListaArmazens, Atual, ArmazensRestantes),
    bestfs1(ArmazensRestantes, [Atual|Cam], CaminhoFinal).


%HeuristicaMaiorMassa
bestfsMassa(ListaArmazens, Data, Final):- ArmazemAtual is 5,
    bestfs2(ListaArmazens, Data, [ArmazemAtual], CaminhoFinal), 
    append(CaminhoFinal, [5], Final).

bestfs2([],_,Cam, CaminhoFinal):- !,
    reverse(Cam, CaminhoFinal).

bestfs2(ListaArmazens, Data, Cam, CaminhoFinal):-
    findall((Massa,[Armazem| Cam]), 
    (member(Armazem, ListaArmazens), entrega(_,Data,Massa,Armazem,_,_), idArmazem(_,Armazem)),
    Novos),


    %sort(+Key, +Order, +List, -Sorted)
    sort(0, @>=, Novos, NovosOrd),

    NovosOrd = [(_,[Atual|_])|_],
    delete(ListaArmazens, Atual, ArmazensRestantes),
    bestfs2(ArmazensRestantes, Data, [Atual|Cam], CaminhoFinal).


%HeuristicaMelhorRelacao
%MassaDividirDistancia

bestfsMassaDistancia(ListaArmazens, Data, Final):- ArmazemAtual is 5,
    bestfs3(ListaArmazens, Data, [ArmazemAtual], CaminhoFinal), 
    append(CaminhoFinal, [5], Final).

bestfs3([],_,Cam, CaminhoFinal):- !,
    reverse(Cam, CaminhoFinal).

bestfs3(ListaArmazens, Data, Cam, CaminhoFinal):-
    Cam = [ArmazemAtual|_],
    findall((Relacao,[ArmazemProximo| Cam]), 
    (distancia(ArmazemAtual,ArmazemProximo,Distancia), member(ArmazemProximo, ListaArmazens), entrega(_,Data,Massa,ArmazemProximo,_,_), idArmazem(_,ArmazemProximo), Relacao is Massa/Distancia),
    Novos),


    %sort(+Key, +Order, +List, -Sorted)
    sort(0, @>=, Novos, NovosOrd),
    %sort(Novos,NovosOrd),
    %reverse(NovosOrd, NO),
    %NO = [(_,[Atual|_])|_],
    NovosOrd = [(_,[Atual|_])|_],
    delete(ListaArmazens, Atual, ArmazensRestantes),
    bestfs3(ArmazensRestantes, Data, [Atual|Cam], CaminhoFinal).





/*
bestfs(Orig,Dest,Cam,Custo):-
    bestfs2(Dest,(0,[Orig]),Cam,Custo).

bestfs2(Dest,(Custo,[Dest|T]),Cam,Custo):-
    !,
    reverse([Dest|T],Cam).

bestfs2(Dest,(Ca,LA),Cam,Custo):-
    LA=[Act|_],
    findall((CaX,[X|LA]), (distancia(Act,X,CX),\+member(X,LA), CaX is Ca+CX), Novos),
    sort(Novos,NovosOrd),
    NovosOrd = [(CM,Melhor)|_],
    bestfs2(Dest,(CM,Melhor),Cam,Custo),
    !.

bestfs2(Dest,(Ca,LA),Cam,Custo):-
    LA=[Act|_],
    findall((CaX,[X|LA]),
    (distancia(Act,X,CX),\+member(X,LA),
    CaX is Ca+CX),Novos),
    sort(Novos,NovosOrd),
    NovosOrd = [_|Tail],
    bestfs2Rec(Dest,Tail,Cam,Custo).

bestfs2Rec(Dest, [(Ca,List)|_],Cam,Custo):-
    bestfs2(Dest,(Ca,List),Cam,Custo),
    !.

bestfs2Rec(Dest, [_|Tail],Cam,Custo):-
    bestfs2Rec(Dest,Tail,Cam,Custo).
*/

