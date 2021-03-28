# SudokuCombinatorialEvolutionSolver

### Introduction

Ces dernières années, des progrès considérables ont été réalisés dans les domaines des neurosciences, des sciences cognitives et de la physiologie en ce qui concerne la manière dont les êtres humains traitent l'information. La recherche actuelle dans l'informatique est impactée par ces progrès notamment dans les domaines de neurosciences computationnelles, de sciences cognitives, de biologie et de méthodes computationnelles inspirées de l'évolution. Il existe tout un tas d’algorithmes directement inspirés par la nature. 

Par exemple, il y a celui de l’évolution différentielle (ED). Très similaire aux recherches de motifs et aux algorithmes génétiques, il utilise le croisement et la mutation. L’ED peut être considéré comme un développement des algorithmes génétiques à quelques différences près. Il est un algorithme de recherche stochastique à tendance auto-organisatrice, basé sur la population sans dérivés en utilisant des nombres réels comme chaînes de solutions, ce qui ne nécessite ni encodage ni décodage. Il effectue des opérations sur chaque composant (ou dimension de la solution) et tout est fait en termes de vecteurs. Cette mutation vectorielle peut être considérée comme une approche plus efficace du point de vue de la mise en œuvre. Également, une perturbation est effectuée sur chaque vecteur de population et on peut donc s'attendre à ce qu'il soit plus efficace. 

Un autre exemple d’algorithme inspiré de la nature est celui de l’optimisation par essaims de particules (OEP ou PSO en anglais). Ici, on n’utilise pas le croisement ou la mutation, mais on se concentre sur le caractère aléatoire des nombres réels et la communication globale entre les particules de l’essaim. Il est également plus facile à mettre en œuvre, car il n'y a pas d’encodage ou de décodage. L'algorithme recherche l'espace d'une fonction « objectif » en ajustant les trajectoires des particules dans des vecteurs de position d'une manière quasi-stochastique. Le mouvement d'une particule en essaim est constitué de deux composantes principales : une composante stochastique et une composante déterministe. 

Un autre exemple d’algorithme inspiré de la nature est celui du comportement de la luciole (Algorithmes Firefly, AF). Cet algorithme est directement inspiré de la lumière clignotante des lucioles qui a pour fonction d’attirer des partenaires d’accouplement (communication) ou d’attirer des proies potentielles. Son intensité lumineuse diminue lorsque la distance augmente. Le clignotement de la lumière peut être formulé de manière à être associé à la fonction « objectif » à optimiser, ce qui permet de formuler de nouveaux algorithmes d'optimisation. L'attrait est proportionnel à la luminosité, les deux diminuant à mesure que leur distance augmente. S'il n'y a pas de luciole plus brillante qu'une autre, le déplacement se fait de façon aléatoire.

Cependant les performances réalisées par ces algorithmes peuvent être contrastées, comme il a été fait par Adam P. Piotrowski, Maciej J. Napiorkowski, Jaroslaw J. Napiorkowski et Pawel M. Rowinski dans leur article « Swarm Intelligence and Evolutionary Algorithms: Performance versus speed ». Dans leur papier ils ont testé et démontré que les algorithmes d'optimisation par essaims de particules sont plus performants lorsque le nombre d’appels de fonction autorisés est faible alors que l’évolution différentielle elle se montre plus performante lorsque ce nombre est élevé. Il est difficile de trouver un algorithme dont les performances seraient adéquates pour tous les nombres d'appels de fonctions testés. Ils ont aussi constaté que certains algorithmes peuvent devenir complètement non fiables sur des problèmes spécifiques du monde réel, même s'ils fonctionnent raisonnablement sur d'autres.

De ces algorithmes inspirés par la nature, découle notre algorithme de l’évolution combinatoire, qui a pour but d’organisé un ensemble d'éléments discrets dans un ordre particulier tout en étant confronté à un problème d’optimisation combinatoire qui peut par exemple être un sudoku comme dans notre projet.

Un problème d'optimisation combinatoire consiste à trouver la meilleure solution dans un ensemble discret dit ensemble des solutions réalisables, il est décrit par une liste de contraintes que doivent satisfaire les solutions réalisables. Pour définir la notion de meilleure solution, une fonction « objectif » est introduite. Pour chaque solution, elle renvoie un réel et la meilleure solution (ou solution optimale) est celle qui minimise ou maximise la fonction « objectif ».

Par exemple, dans un sudoku, il y a plusieurs contraintes. Chaque ligne de la grille de solution 9x9 doit contenir les nombres de 1 à 9, sans doublons. Chaque colonne doit contenir les nombres 1 à 9. Chaque sous-grille 3x3 doit contenir les nombres 1 à 9. Et la grille de solution ne peut changer aucune des valeurs de départ dans la grille de problème.

L'optimisation de l'évolution combinatoire utilise des idées issues de plusieurs algorithmes bio-inspirés. L'algorithme maintient une collection d'organismes virtuels. Chaque organisme représente une solution possible au problème. L'évolution combinatoire est un processus itératif où à chaque itération, chaque organisme tente de trouver une meilleure solution en examinant une nouvelle solution possible.

Une fois que tous les organismes ont eu une chance de s'améliorer, deux bonnes solutions d'organismes sont sélectionnées et utilisées pour donner naissance à un nouvel organisme, qui remplace une mauvaise solution. Ainsi, la population d'organismes évolue avec le temps. Si une solution optimale n'est pas trouvée après un certain temps (nombre max d’itérations), l'algorithme est redémarré en tuant tous les organismes et en créant une nouvelle population. Ce processus de redémarrage a pour but de contrer la tendance de l’algorithme à se bloquer trop rapidement lorsqu’il trouve une très bonne solution. C’est une technique courante de nombreux algorithmes d’optimisation.

```c#

     // Modele CNN
        var model = new Sequential();

        model.Add(new Conv2D(64, kernel_size: (3, 3).ToTuple(), padding: 'same', activation: "relu", input_shape: (9, 9, 1));
        model.Add(new BatchNormalization());
        model.Add(new Conv2D(64, (3, 3).ToTuple(), padding: 'same', activation: "relu"));
        model.Add(new BatchNormalization());
        model.Add(new Conv2D(128, (1, 1).ToTuple(), padding: 'same', activation: "relu"));


        model.Add(new Flatten());
        model.Add(new Dense(81*9));
        model.Add(new Reshape((-1, 9)));
        model.Add(new Activation('softmax'));

```
