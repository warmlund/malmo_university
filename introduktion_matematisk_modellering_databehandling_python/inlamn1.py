# -*- coding: utf-8 -*-
"""
Created on Mon Jun  3 20:11:43 2024
videolänk: https://youtu.be/9WKe_0mM1Sg
@author: Emelie Wärmlund
"""
import numpy as np #importerar numpy för att beräkna skalärprodukt
#%% uppgift 1a
# summa.py
s = 0 # sätt summa till noll
for i in range(1,101): # loopa från 1 till 100, måste skriva 101 inte 100
    s = s + i # addera term till summan
print('Summan är ',s) # skriv ut resultatet

#%% uppgift 1b
s = 0 # sätt summa till noll
for i in range(1,11): # loopa från 1 till 10, måste skriva 11 inte 10
    s = s + i # addera term till summan
print('Summan är ',s) # skriv ut resultatet

#%% uppgift 2a
x=9**1/2 #sätter variabel x till 9 upphöjt i 1/2 utan parentes
y=9**(1/2) #sätter variabel y till 9 upphöjt i 1/2 inom parentes
print('x=',x,'y=',y) #skriver ut resultatet

#%% uppgift 2b
a=1.52*10**-8 #sätter variabel a
b=6.18*10**9 #sätter variabel b
c=np.dot(a,b) #sätter c som skalärprodukt mellan a och b
print(round(c,1)) #skriver resultat och avrundar till en decimal

#%% uppgift 3a och 3b
f=lambda x,k,m: k*x+m #definierar lambda-uttryck
a=f(1,2,3) #sätter variabel a med lambdauttryck och sätter värden på variabler x, k och m
print(a) #skriver ut resultat a

#%% uppgift 4
u=[10,20,3,4,-52]
#4a
a=len(u) #sätter variabel a för antalet element i lista u
#4b
print(u[0],u[1],u[len(u)-1]) #skriver ut första, andra och sista elementet i lista u, sista index i listan är längden på listan len(u) minus 1
#4c
u.sort() #sorterar lista u
print(u) #skriver ut sorterad lista

#%% uppgift 5a
# energispar.py
Ugamla = float(input('U-värde för gamla fönster '))
Unya = float(input('U-värde för nya fönster '))
area = float(input('Fönsterarea '))
gradtimmar = float(input('Gradtimmar för orten '))
elpris = float(input('Elpris '))
energibesparing = (Ugamla - Unya)*area*gradtimmar
kostnadsbesparing = energibesparing*elpris
print('Energibesparing ', round(energibesparing), 'kWh per år')
print('Kostnadsbesparing', round(kostnadsbesparing), 'kr per år')

##Energibesparing  7910 kWh per år
##Kostnadsbesparing 15820 kr per år

#%% uppgift 5b
fast_pris=float(input('Fast avgift: ')) #input för fast pris
antal_enheter=int(input('Antal levererade enheter: ')) #input för antal enheter int istället för float eftersom det är heltal
pris_per_enhet=float(input('Pris per enhet: ')) #input för pris per enhet
pris_utan_moms=fast_pris+(antal_enheter*pris_per_enhet) #beräknar pris utan moms
pris_med_moms=pris_utan_moms*1.25 #beräknar pris med moms
print('Pris utan moms:', pris_utan_moms)
print('Pris med moms:', pris_med_moms)

#%% uppgift 6

# 6a
x=np.array([1,2,3]) #initierar variabel x
y=np.array([4,5,6]) #initierar variabel y
print('x=',x,'y=',y) #skriver resultatet

#6b
s=np.array(x+5) #skapar ny vektor genom att addera 5 till varje element i vektor x
print(s) #skriver resultatet

#6c
#t=np.array([a*8 for a in x]) #skapar ny vektor genom att multiplicera varje element i vektor x med 8
t=np.array(x*8)
print (t)

#6d
u=np.array(s+t)  #adderar s och t
print(u) #skriver ut resultatet

#6e
y=np.sqrt(x) #skapar ny vektor som består av kvadratroten ur varje element i vektor x 
print(y) #skriver resultatet

#%% uppgift 7
# temperatur.py
# beräknar olika temperaturmedelvärden
# Läs in temperaturvärden från filen T10365.txt.
# Lagra i 10 x 365 matrisen T
import numpy as np
T = np.loadtxt('T10365.txt')
# max, min, medelvärde för 1981-90, avrunda till en decimal
print() # ger en tom rad
print('Maximal temperatur under 10 år', np.round( np.max(T),1 ) )
print('Minimal temperatur under 10 år', np.round( np.min(T),1 ) )
print('Medeltemperatur under 10 år ', np.round( np.mean(T),1 ) )
# medeltemp. för jan. (dag 1-31) och jun. (dag 152-181), avrunda till en decimal
print()
print('Medeltemperatur januari ', np.round( np.mean(T[:,0:31]),1 ) )
print('Medeltemperatur juni ', np.round( np.mean(T[:,151:181]),1 ) )
# årsmedelvärde för 1981 till 1990, avrunda till en decimal
print()
print('Årsmedeltemperatur för 1981 ', np.round( np.mean(T[0,:]),1 ) )
print('Årsmedeltemperatur för 1990 ', np.round( np.mean(T[9,:]),1) )

# 7b(i)skriver ut index för år och dag då temperaturen är maximal
print()
print('Rad-och kolonnindex för maximaltemperatur',np.unravel_index(np.argmax(T),T.shape))

# 7b(ii) skriver ut medeltemperaturen för februari
print()
print('Medeltemperatur februari',np.round(np.mean(T[:,32:59]),1))

#7b(iii) skriver ut årsmedeltemperaturen för 1985
print()
print('Årsmedeltemperatur för 1985', np.round(np.mean(T[4,:]),1))